# Syrx.Commanders.Databases remediation backlog

## overview

This backlog converts the March 21, 2026 security and performance research outputs into GitHub-issue-style work items with explicit scope, sequencing, and binary acceptance criteria.

## goals

- Eliminate confirmed secret exposure and connection-lifecycle risks first.
- Reduce CI/CD blast radius and supply-chain risk with minimal delivery disruption.
- Sequence core runtime fixes so security and performance changes do not create duplicate churn.
- Defer higher-risk structural refactors until benchmarks, API decisions, or policy decisions exist.

## scope

In scope:
- Confirmed security findings SEC-001 through SEC-004.
- Confirmed performance findings PERF-001 through PERF-005.
- Constrained-hypothesis follow-up for HYP-001 and HYP-002 where planning or ADR work is required.

Out of scope:
- Implementing any remediation.
- Changing public APIs without explicit approval.
- Approving scanner policy, telemetry schema, or architectural governance by implication.

## dependencies

- [.docs/research/security/Syrx.Commanders.Databases-security-research-report-20260321.md](research/security/Syrx.Commanders.Databases-security-research-report-20260321.md)
- [.docs/research/security/Syrx.Commanders.Databases-security-remediation-priority-plan-20260321.md](research/security/Syrx.Commanders.Databases-security-remediation-priority-plan-20260321.md)
- [.docs/research/performance/Syrx.Commanders.Databases-performance-research-report-20260321.md](research/performance/Syrx.Commanders.Databases-performance-research-report-20260321.md)
- [.docs/remediation-approval-checklist-20260321.md](remediation-approval-checklist-20260321.md)

## issue backlog

### GH-001 remove connection-string disclosure from exception messages

- Priority: Must
- Category: Security
- Related IDs: SEC-001, AC-001, AC-002, AC-003
- Owner recommendation: csharp-engineering
- File targets:
  - [src/Syrx.Commanders.Databases.Settings.Extensions/CommanderSettingsBuilder.cs](../src/Syrx.Commanders.Databases.Settings.Extensions/CommanderSettingsBuilder.cs)
  - [tests/unit/Syrx.Commanders.Databases.Settings.Extensions.Tests.Unit/CommanderSettingsBuilderTests/AddConnectionString.cs](../tests/unit/Syrx.Commanders.Databases.Settings.Extensions.Tests.Unit/CommanderSettingsBuilderTests/AddConnectionString.cs)
- Problem statement:
  Current exception text exposes raw connection-string values, which creates direct secret leakage risk through logs, telemetry, and error surfaces.
- Implementation notes:
  Replace secret-bearing text with alias-only context and stable wording. Add regression tests that fail if raw connection-string content appears in the thrown message.
- Acceptance criteria:
  - AC-001: No thrown exception from duplicate or conflicting connection-string registration includes a raw connection-string value.
  - AC-002: Unit tests assert that exception text contains alias or stable diagnostic context only.
  - AC-003: Existing builder behavior remains unchanged apart from sanitized exception text.

### GH-002 dispose async query connections deterministically in the simple async path

- Priority: Must
- Category: Performance, Reliability
- Related IDs: PERF-003, AC-004, AC-005
- Owner recommendation: csharp-engineering
- File targets:
  - [src/Syrx.Commanders.Databases/DatabaseCommander.QueryAsync.Multimap.cs](../src/Syrx.Commanders.Databases/DatabaseCommander.QueryAsync.Multimap.cs)
  - [tests/integration/Syrx.Commanders.Databases.Tests.Integration/DatabaseCommanderTests/QueryAsync.Multimap.cs](../tests/integration/Syrx.Commanders.Databases.Tests.Integration/DatabaseCommanderTests/QueryAsync.Multimap.cs)
- Problem statement:
  The simple async query overload creates a connection without deterministic disposal, increasing pool-pressure and resource-lifetime risk under sustained concurrency.
- Implementation notes:
  Align the simple async overload with the disposal pattern already used by the more complex overloads in the same file.
- Acceptance criteria:
  - AC-004: All async query overloads that create a connection dispose it deterministically before returning control to the caller.
  - AC-005: Integration coverage or equivalent regression coverage demonstrates unchanged query results after the lifecycle fix.

Validation note (2026-03-21):
- In this repository snapshot, the integration test suite under `tests/integration/Syrx.Commanders.Databases.Tests.Integration` is abstract-only and currently yields zero discoverable runnable tests without concrete derived fixtures.
- GH-002 validation is therefore satisfied via equivalent executable unit regression coverage in `tests/unit/Syrx.Commanders.Databases.Tests.Unit/DatabaseCommanderTests/QueryAsync.Multimap.cs`, which asserts deterministic disposal in the simple async query path.

### GH-003 harden workflow token permissions in publish pipeline

- Priority: Must
- Category: Security, CI/CD
- Related IDs: SEC-002, AC-006, AC-007
- Owner recommendation: csharp-engineering
- File targets:
  - [.github/workflows/publish.yml](../.github/workflows/publish.yml)
- Problem statement:
  The publish workflow does not declare explicit token permissions, leaving effective privilege scope dependent on repository or organization defaults.
- Implementation notes:
  Add explicit least-privilege workflow permissions and elevate only where justified by a specific job action.
- Acceptance criteria:
  - AC-006: The publish workflow defines an explicit permissions block.
  - AC-007: No job receives broader permissions than required for its defined actions.

### GH-004 pin third-party GitHub Actions to immutable SHAs

- Priority: Must
- Category: Security, CI/CD
- Related IDs: SEC-003, AC-008, AC-009
- Owner recommendation: csharp-engineering
- File targets:
  - [.github/workflows/publish.yml](../.github/workflows/publish.yml)
- Problem statement:
  Mutable major-version tags increase supply-chain drift and compromise exposure in the publish workflow.
- Implementation notes:
  Pin each third-party action reference to an immutable commit SHA and retain readable annotations for the upstream version when useful.
- Acceptance criteria:
  - AC-008: All third-party actions in the publish workflow are pinned to immutable commit SHAs.
  - AC-009: Workflow behavior remains functionally equivalent after pinning.

### GH-005 combine async execute-path scaling fixes with sanitized failure telemetry

- Priority: Must
- Category: Security, Performance, Observability
- Related IDs: PERF-001, SEC-004, AC-010, AC-011, AC-012
- Owner recommendation: csharp-engineering
- File targets:
  - [src/Syrx.Commanders.Databases/DatabaseCommander.ExecuteAsync.cs](../src/Syrx.Commanders.Databases/DatabaseCommander.ExecuteAsync.cs)
  - [src/Syrx.Commanders.Databases/DatabaseCommander.Execute.cs](../src/Syrx.Commanders.Databases/DatabaseCommander.Execute.cs)
  - [tests/integration/Syrx.Commanders.Databases.Tests.Integration/DatabaseCommanderTests/ExecuteAsync.cs](../tests/integration/Syrx.Commanders.Databases.Tests.Integration/DatabaseCommanderTests/ExecuteAsync.cs)
  - [tests/integration/Syrx.Commanders.Databases.Tests.Integration/DatabaseCommanderTests/Execute.cs](../tests/integration/Syrx.Commanders.Databases.Tests.Integration/DatabaseCommanderTests/Execute.cs)
- Dependencies:
  - Approval gate AG-001
- Problem statement:
  The async execute path uses synchronous connection open, and both execute paths rethrow transaction failures without actionable sanitized context.
- Implementation notes:
  Plan this as one change to avoid revisiting the same transaction code twice. The logging contract must be approved before implementation. SQL text, parameters, and secrets must not be emitted.
- Acceptance criteria:
  - AC-010: Async execute paths use asynchronous connection opening where provider capabilities support it.
  - AC-011: Transaction failure paths emit approved structured diagnostics without SQL text, raw parameters, or secrets.
  - AC-012: Rollback and exception propagation semantics remain unchanged for callers.

### GH-006 add CI security detection gates after policy approval

- Priority: Should
- Category: Security, CI/CD
- Related IDs: SEC-003, AC-013, AC-014, AC-015
- Owner recommendation: architecture-and-ddd and csharp-engineering
- File targets:
  - [.github/workflows/publish.yml](../.github/workflows/publish.yml)
  - [Directory.Build.props](../Directory.Build.props)
- Dependencies:
  - Approval gate AG-002
- Problem statement:
  The repository currently lacks in-workflow vulnerability review, static analysis, and secret-scanning gates.
- Implementation notes:
  Separate this from GH-003 and GH-004 so policy selection and enforcement thresholds can be reviewed without delaying immediate workflow hardening.
- Acceptance criteria:
  - AC-013: The approved scanner stack runs on pull requests and protected-branch workflows.
  - AC-014: Blocking thresholds are encoded explicitly rather than left implicit.
  - AC-015: Ownership for triage and remediation of scan failures is documented.

### GH-007 benchmark and then remove reflection-heavy multiple-result materialization

- Priority: Should
- Category: Performance
- Related IDs: PERF-002, AC-016, AC-017, AC-018
- Owner recommendation: performance-researcher and csharp-engineering
- File targets:
  - [src/Syrx.Commanders.Databases/DatabaseCommander.Query.Multiple.cs](../src/Syrx.Commanders.Databases/DatabaseCommander.Query.Multiple.cs)
  - [src/Syrx.Commanders.Databases/DatabaseCommander.QueryAsync.Multiple.cs](../src/Syrx.Commanders.Databases/DatabaseCommander.QueryAsync.Multiple.cs)
  - [tests/integration/Syrx.Commanders.Databases.Tests.Integration/DatabaseCommanderTests/Query.Multiple.cs](../tests/integration/Syrx.Commanders.Databases.Tests.Integration/DatabaseCommanderTests/Query.Multiple.cs)
  - [tests/integration/Syrx.Commanders.Databases.Tests.Integration/DatabaseCommanderTests/QueryAsync.Multiple.cs](../tests/integration/Syrx.Commanders.Databases.Tests.Integration/DatabaseCommanderTests/QueryAsync.Multiple.cs)
- Dependencies:
  - Approval gate AG-003
- Problem statement:
  Per-call reflection and dynamic result extraction in the multiple-result query paths add avoidable CPU and allocation overhead.
- Implementation notes:
  Do not approve implementation until a benchmark harness and acceptance threshold exist. The preferred direction is cached delegates or typed fast paths, but only if measured benefit justifies complexity.
- Acceptance criteria:
  - AC-016: A before-and-after benchmark exists for representative multiple-result query scenarios.
  - AC-017: The approved implementation reduces allocations or execution cost relative to baseline for the benchmarked scenarios.
  - AC-018: Existing query semantics and result ordering remain unchanged.

### GH-008 decide the future of the pseudo-async execute delegate overload

- Priority: Should
- Category: Performance, API Design
- Related IDs: PERF-004, AC-019, AC-020
- Owner recommendation: architecture-and-ddd and csharp-engineering
- File targets:
  - [src/Syrx.Commanders.Databases/DatabaseCommander.ExecuteAsync.cs](../src/Syrx.Commanders.Databases/DatabaseCommander.ExecuteAsync.cs)
  - [tests/integration/Syrx.Commanders.Databases.Tests.Integration/DatabaseCommanderTests/ExecuteAsync.cs](../tests/integration/Syrx.Commanders.Databases.Tests.Integration/DatabaseCommanderTests/ExecuteAsync.cs)
- Dependencies:
  - Approval gate AG-004
- Problem statement:
  The current async execute overload wraps synchronous delegate execution with Task.FromResult, which creates pseudo-async behavior and API ambiguity.
- Implementation notes:
  This requires an explicit public API decision before implementation. Valid outcomes include retaining the current contract, adding a true async overload, or formally deprecating the faux-async path.
- Acceptance criteria:
  - AC-019: The repository has an explicit approved decision for the public contract of this overload family.
  - AC-020: Any chosen implementation preserves documented caller expectations or includes an approved migration path.

### GH-009 define configuration trust boundaries for file-based settings and command provenance

- Priority: Could
- Category: Security, Architecture
- Related IDs: HYP-001, HYP-002, AC-021, AC-022, AC-023
- Owner recommendation: architecture-and-ddd with syrx-data-access input
- File targets:
  - [src/Syrx.Commanders.Databases.Settings.Extensions.Json/UseFileExtensions.cs](../src/Syrx.Commanders.Databases.Settings.Extensions.Json/UseFileExtensions.cs)
  - [src/Syrx.Commanders.Databases.Settings.Extensions.Xml/UseFileExtensions.cs](../src/Syrx.Commanders.Databases.Settings.Extensions.Xml/UseFileExtensions.cs)
  - [src/Syrx.Commanders.Databases/DatabaseCommander.cs](../src/Syrx.Commanders.Databases/DatabaseCommander.cs)
  - [tests/unit/Syrx.Commanders.Databases.Settings.Extensions.Json.Tests.Unit/ServiceCollectionExtensionsTests/UseFile.cs](../tests/unit/Syrx.Commanders.Databases.Settings.Extensions.Json.Tests.Unit/ServiceCollectionExtensionsTests/UseFile.cs)
  - [tests/unit/Syrx.Commanders.Databases.Settings.Extensions.Xml.Tests.Unit/ServiceCollectionExtensionsTests/UseFile.cs](../tests/unit/Syrx.Commanders.Databases.Settings.Extensions.Xml.Tests.Unit/ServiceCollectionExtensionsTests/UseFile.cs)
- Dependencies:
  - Approval gate AG-005
- Problem statement:
  Configuration file names and command text are currently treated as trusted in practice, but that trust boundary is not explicitly documented or governed.
- Implementation notes:
  Start with an ADR or equivalent policy artifact. Only implement additional guards or enforcement after boundary ownership is explicit.
- Acceptance criteria:
  - AC-021: The repository records whether file names and command settings are trusted application-owned inputs or require library-level validation.
  - AC-022: Any resulting validation or non-validation decision is documented with rationale.
  - AC-023: Tests or documentation are updated to match the approved trust model.

### GH-010 decide whether settings lookup should be pre-indexed at load time

- Priority: Could
- Category: Performance, Architecture
- Related IDs: PERF-005, AC-024, AC-025
- Owner recommendation: architecture-and-ddd and csharp-engineering
- File targets:
  - [src/Syrx.Commanders.Databases.Settings.Readers/DatabaseCommandReader.cs](../src/Syrx.Commanders.Databases.Settings.Readers/DatabaseCommandReader.cs)
  - [src/Syrx.Commanders.Databases.Connectors/DatabaseConnector.cs](../src/Syrx.Commanders.Databases.Connectors/DatabaseConnector.cs)
  - [src/Syrx.Commanders.Databases/DatabaseCommander.cs](../src/Syrx.Commanders.Databases/DatabaseCommander.cs)
  - [tests/unit/Syrx.Commanders.Databases.Settings.Readers.Tests.Unit/DatabaseCommandReaderTests/GetCommand.cs](../tests/unit/Syrx.Commanders.Databases.Settings.Readers.Tests.Unit/DatabaseCommandReaderTests/GetCommand.cs)
  - [tests/unit/Syrx.Commanders.Databases.Connectors.Tests.Unit/DatabaseConnectorTests/CreateConnection.cs](../tests/unit/Syrx.Commanders.Databases.Connectors.Tests.Unit/DatabaseConnectorTests/CreateConnection.cs)
- Dependencies:
  - Approval gate AG-003
  - Approval gate AG-005
- Problem statement:
  Current cache-miss lookup behavior scales linearly with configuration size, but any pre-indexing change affects configuration lifecycle and initialization semantics.
- Implementation notes:
  Treat this as a structural design decision rather than a standalone micro-optimization.
- Acceptance criteria:
  - AC-024: The repository has an approved decision on whether to keep cache-on-miss traversal or adopt load-time indexing.
  - AC-025: If load-time indexing is approved, tests verify unchanged lookup behavior and expected initialization semantics.

## approval gates

### AG-001 approve logging contract for transactional failure telemetry

- Required before: GH-005
- Decision needed:
  Approve which structured fields are allowed in failure logs. Approved fields must exclude SQL text, raw parameters, and secrets.

### AG-002 approve CI scanner stack and blocking thresholds

- Required before: GH-006
- Decision needed:
  Select scanner tooling, merge-blocking severity thresholds, and failure triage ownership.

### AG-003 approve benchmark requirement for hot-path performance refactors

- Required before: GH-007, GH-010
- Decision needed:
  Confirm the benchmark or telemetry evidence required before approving structural performance work.

### AG-004 approve public API direction for async execute delegate overloads

- Required before: GH-008
- Decision needed:
  Decide whether the current contract is retained, extended, or deprecated.

### AG-005 approve configuration trust-boundary policy

- Required before: GH-009, GH-010
- Decision needed:
  Decide whether configuration filenames and command text are trusted application-owned inputs or require additional library-level enforcement.

## recommended execution sequence

1. GH-001
2. GH-002
3. GH-003
4. GH-004
5. GH-005
6. GH-006
7. GH-007
8. GH-008
9. GH-009
10. GH-010

## notes for issue creation

- GH-001 through GH-005 are the best first wave if you want immediate risk reduction.
- GH-006 should not be opened as implementation-ready unless AG-002 is answered in the same planning cycle.
- GH-007 through GH-010 are backlog-ready but intentionally gated to prevent speculative refactors.