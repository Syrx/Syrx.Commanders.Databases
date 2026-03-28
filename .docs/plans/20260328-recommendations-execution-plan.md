# Recommendations Execution Implementation Plan

> **For agentic workers:** REQUIRED WORKFLOW: Use the `planning-and-research` agent for planning handoff, then use `csharp-engineering` or `debug` to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Convert documented recommendations into executable, validated workstreams that close documentation drift and broken-link risks.

**Architecture:** Use an orchestrated, parallel-safe documentation remediation flow. Independent file creation tasks run in parallel; shared index and validation updates run serially to avoid merge conflicts.

**Tech Stack:** Markdown, PowerShell link validation, .NET repository docs conventions

---

## Recommendation Scope Converted to Actions

1. Execute Phase 3b completion for missing reference pages.
2. Re-run link validation and resolve broken internal links.
3. Align coverage/status messaging with actual repository state.
4. Record execution in `.docs/changes` with traceable file inventory.

## Agent and Skill Routing

- Planning and sequencing: `orchestrator` + `writing-plans` skill
- Evidence checks and inventory lookups: `Explore` agent
- Documentation generation and refresh: `planning-and-research` agent + `msdn-documentation` skill guidance
- .NET/API verification of technical claims: `csharp-engineering` agent
- Final quality gate review: `code-reviewer` agent

## Parallelization Strategy

Run these in parallel because they touch disjoint files:
- Stream A: Create missing configuration pages under `.docs/reference/configuration/`
- Stream B: Create missing project pages under `.docs/reference/projects/`

Run these serially after A and B complete:
- Stream C: Update `.docs/reference/index.md` and `.docs/reference/coverage-report.md`
- Stream D: Re-run link validation and produce release-ready status summary

### Task 1: Baseline and Drift Confirmation

**Files:**
- Modify: `.docs/reference/coverage-report.md`
- Modify: `.docs/reference/index.md`
- Test: none

- [x] **Step 1: Confirm current missing file inventory**

Run: `Get-ChildItem .docs/reference -Recurse -Filter *.md | Select-Object -ExpandProperty FullName`
Expected: List shows existing markdown files and confirms missing referenced pages.

- [x] **Step 2: Confirm current broken-link set**

Run: repository markdown link checker script used in prior audit.
Expected: Output includes missing targets under `configuration/` and `projects/`.

- [x] **Step 3: Update plan tracker for confirmed baseline**

Mark this task complete once baseline results are captured in the changes file.

### Task 2: Stream A - Create Configuration Reference Pages (Parallel)

**Files:**
- Create: `.docs/reference/configuration/xml-schema.md`
- Create: `.docs/reference/configuration/builder-api.md`
- Create: `.docs/reference/configuration/examples.md`
- Modify: `.docs/reference/configuration/index.md`
- Test: none

- [x] **Step 1: Draft `xml-schema.md` with implementation-backed sections**

Include: summary, schema structure, mapping to settings types, examples, security notes.

- [x] **Step 2: Draft `builder-api.md` with fluent API examples**

Include: `CommanderSettingsBuilder` usage, method mapping, thread-safety notes, error handling behavior.

- [x] **Step 3: Draft `examples.md` with end-to-end JSON/XML/builder scenarios**

Include minimal and advanced examples with cross-links to schema pages.

- [x] **Step 4: Update configuration index links and section summaries**

Ensure `configuration/index.md` references all configuration child pages.

### Task 3: Stream B - Create Project Reference Pages (Parallel)

**Files:**
- Create: `.docs/reference/projects/commanders-databases.md`
- Create: `.docs/reference/projects/builders.md`
- Create: `.docs/reference/projects/connectors.md`
- Create: `.docs/reference/projects/connectors-extensions.md`
- Create: `.docs/reference/projects/extensions.md`
- Create: `.docs/reference/projects/settings.md`
- Create: `.docs/reference/projects/settings-extensions.md`
- Create: `.docs/reference/projects/settings-extensions-json.md`
- Create: `.docs/reference/projects/settings-extensions-xml.md`
- Create: `.docs/reference/projects/settings-readers.md`
- Create: `.docs/reference/projects/settings-readers-extensions.md`
- Test: none

- [x] **Step 1: Generate page set with consistent MSDN-style sections**

Each page includes: summary, key types, notable APIs, usage notes, thread-safety/security notes, related links.

- [x] **Step 2: Verify page claims against code symbols**

Validate all API names and behavior statements against current source files.

- [x] **Step 3: Ensure cross-links are relative and valid**

Use only in-repo relative links; avoid links to planned-but-missing pages.

### Task 4: Stream C - Integrate and Update Root Reference Pages (Serial)

**Files:**
- Modify: `.docs/reference/index.md`
- Modify: `.docs/reference/coverage-report.md`
- Modify: `.docs/api-reference.md`
- Test: none

- [x] **Step 1: Update index navigation status to match actual files**

Remove stale completion claims and ensure all listed links resolve.

- [x] **Step 2: Refresh coverage report metrics and exclusions**

Recalculate completion and list any true exclusions with rationale.

- [x] **Step 3: Align `.docs/api-reference.md` with new reference tree**

Keep quick-start value while pointing to authoritative per-project pages.

### Task 5: Stream D - Validation and Publication Gate (Serial)

**Files:**
- Modify: `.docs/changes/20260328-recommendations-execution-changes.md`
- Test: all reference markdown link paths

- [x] **Step 1: Run deterministic internal link validation**

Run: link audit script over `.docs/reference/**/*.md`.
Expected: zero broken internal links.

- [x] **Step 2: Spot-check technical claims**

Check thread-safety, transaction behavior, and command resolution claims against source.

- [x] **Step 3: Record release summary**

Update changes file with total files created/modified and outstanding follow-ups.

### Task 6: Review Gate

**Files:**
- Modify: `.docs/changes/20260328-recommendations-execution-changes.md`

- [x] **Step 1: Run code-reviewer pass over documentation diff**

Focus on factual drift, broken links, and consistency of guidance.

- [x] **Step 2: Address findings and finalize**

Apply fixes for any major/important findings before completion.

## Success Criteria

- [x] All missing configuration and project reference pages exist.
- [x] `.docs/reference/index.md` has zero dead internal links.
- [x] Coverage report reflects actual file inventory.
- [x] No newly introduced factual drift against implementation code.
- [x] Changes log contains full release summary.

## Execution Notes

- Process tasks in order, except Task 2 and Task 3 which are explicitly parallel.
- Keep claims evidence-backed; if uncertain, state "Not observed in code".
- Avoid speculative performance/security statements.
