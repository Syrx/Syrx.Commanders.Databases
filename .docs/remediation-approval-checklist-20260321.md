# Syrx.Commanders.Databases remediation approval checklist

## purpose

This checklist captures the decisions maintainers must make before the gated remediation backlog items move into implementation.

## decision checklist

### DEC-001 transactional failure logging contract

- Blocks: GH-005
- Decision required:
  Approve the structured fields allowed in execute-path failure logs.
- Must include:
  - command key or alias
  - repository type or operation source
  - correlation or operation identifier when available
- Must not include:
  - SQL text
  - raw parameter values
  - connection strings
  - secrets or credentials
- Maintainer outcome:
  - Approved
  - Rejected
  - Needs revision

### DEC-002 CI security scanner stack and enforcement policy

- Blocks: GH-006
- Decision required:
  Approve which CI scanners are required and which findings block merge.
- Must define:
  - dependency review or SCA tool
  - SAST tool
  - secret scanning tool
  - severity thresholds for fail versus warn
  - remediation owner for failed checks
- Maintainer outcome:
  - Approved
  - Rejected
  - Needs revision

### DEC-003 benchmark requirement for hot-path performance work

- Blocks: GH-007, GH-010
- Decision required:
  Approve the evidence threshold required before structural performance refactors are allowed.
- Must define:
  - whether BenchmarkDotNet or equivalent is required
  - the scenarios to benchmark
  - the metrics to compare, such as mean time and allocations
  - the minimum improvement required to justify added complexity
- Maintainer outcome:
  - Approved
  - Rejected
  - Needs revision

### DEC-004 public API direction for async execute delegate overloads

- Blocks: GH-008
- Decision required:
  Approve the public contract for the pseudo-async execute overload family.
- Options:
  - retain current contract unchanged
  - add a true async overload and keep the current overload
  - deprecate the current overload with a migration path
- Must define:
  - backward-compatibility expectation
  - whether deprecation messaging is required
  - whether documentation changes are required before release
- Maintainer outcome:
  - Approved
  - Rejected
  - Needs revision

### DEC-005 configuration trust-boundary policy

- Blocks: GH-009, GH-010
- Decision required:
  Approve whether configuration filenames and command text are trusted application-owned inputs or require additional library-level validation.
- Must define:
  - trusted source assumptions for file-based configuration
  - whether path validation belongs in this library
  - whether command text provenance is governed outside the library
  - whether an ADR is required before implementation
- Maintainer outcome:
  - Approved
  - Rejected
  - Needs revision

## recommended approval order

1. DEC-001
2. DEC-002
3. DEC-003
4. DEC-004
5. DEC-005

## fast-path guidance

- If the goal is immediate risk reduction, DEC-001 is the only decision needed before the combined execute-path hardening item GH-005 can begin.
- GH-001 through GH-004 do not require these checklist decisions and can proceed independently once approved for implementation.
- DEC-003 through DEC-005 should be resolved before approving structural performance or trust-boundary changes.

## implementation validation note

- GH-002 currently uses equivalent unit regression coverage for acceptance because the integration suite in this repository snapshot is abstract-only and discovers zero runnable tests without concrete derived fixtures.