[![StepSecurity Maintained Action](https://raw.githubusercontent.com/step-security/maintained-actions-assets/main/assets/maintained-action-banner.png)](https://docs.stepsecurity.io/actions/stepsecurity-maintained-actions)

[![Test check-metas](https://github.com/step-security/Cysharp-Actions/actions/workflows/_test-check-metas.yaml/badge.svg?event=pull_request)](https://github.com/step-security/Cysharp-Actions/actions/workflows/_test-check-metas.yaml)

# Cysharp Actions

Composite GitHub Actions for Unity CI/CD pipelines, maintained by [StepSecurity](https://stepsecurity.io).

This repository provides reusable actions that handle common Unity build and validation tasks. Each action is pinned to specific dependency versions for reproducibility and security.

## Available Actions

| Action | Description |
|--------|-------------|
| [check-metas](#check-metas) | Detect uncommitted Unity `.meta` files |
| [unity-builder](#unity-builder) | Build Unity projects with serial masking |

---

### check-metas

> [action.yaml](https://github.com/step-security/Cysharp-Actions/blob/main/.github/actions/check-metas/action.yaml)

Scans a Unity project directory for untracked `.meta` files and optionally fails the workflow if any are found. This prevents builds from silently introducing `.meta` files that were never committed.

**Inputs**

| Name | Required | Default | Description |
|------|----------|---------|-------------|
| `directory` | Yes | — | Path to the Unity project folder to scan |
| `exit-on-error` | No | `true` | Fail the step when uncommitted `.meta` files are detected |

**Outputs**

| Name | Description |
|------|-------------|
| `meta-exists` | `true` if untracked `.meta` files were found, `false` otherwise |

**Example**

```yaml
- uses: actions/checkout@v6
- uses: step-security/Cysharp-Actions/.github/actions/check-metas@v1
  with:
    directory: ./src/MyUnityProject
```

---

### unity-builder

> [action.yaml](https://github.com/step-security/Cysharp-Actions/blob/main/.github/actions/unity-builder/action.yaml)

Wraps [game-ci/unity-builder](https://github.com/game-ci/unity-builder) and automatically masks the `UNITY_SERIAL` environment variable in logs to prevent license key leaks.

**Inputs**

| Name | Required | Default | Description |
|------|----------|---------|-------------|
| `targetPlatform` | Yes | — | Unity build target (e.g. `StandaloneLinux64`) |
| `unityVersion` | No | `auto` | Unity editor version, or `auto` to detect from project settings |
| `projectPath` | Yes | — | Relative path to the Unity project directory |
| `buildMethod` | Yes | — | Fully-qualified static method to invoke for the build |
| `customParameters` | No | — | Additional CLI arguments forwarded to Unity |
| `versioning` | No | `None` | Versioning strategy (e.g. `None`, `Semantic`, `Custom`) |

**Example**

```yaml
- uses: actions/checkout@v6
- uses: step-security/Cysharp-Actions/.github/actions/unity-builder@v1
  with:
    projectPath: src/MyProject.Unity
    unityVersion: "2022.3.10f1"
    targetPlatform: StandaloneLinux64
    buildMethod: PackageExporter.Export
```
