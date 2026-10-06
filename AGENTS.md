# AGENTS.md — fixture de prueba de I-62 (FIXTURE_LOCAL)

Este repositorio es el **sistema bajo prueba** (plano c) de los pilotos F6 de I-62. No es RackCad. Sus reglas I62 rigen **solo aquí**, activadas por
el merge marcado `TEST-ACTIVATION` (ver `FIXTURE-MANIFEST.json`). Nada de este repositorio acredita un gate, un READY, una aprobación del Owner o una
integración de RackCad, ni puede cambiar su `main`, sus contadores, sus decisiones o su custodia (P-16).

## Leer primero

1. [docs/WORKFLOW.md](docs/WORKFLOW.md) — flujo de iniciativas, punto de entrada de compatibilidad (§12).
2. [docs/AUTOMATION_PLAN.md](docs/AUTOMATION_PLAN.md) — ejecución delegada (§16) y su resolver (16.13).
3. [docs/automation/agent-execution/README.md](docs/automation/agent-execution/README.md) — procedimientos.
4. Verificar el estado REAL con `git log --oneline -10` antes de asumir nada.

## Comandos canonicos

```powershell
git status
git log --oneline -10
dotnet test tests/Fixture.Tests/Fixture.Tests.csproj
```

## Jobs requeridos

La CI de este repositorio tiene **dos** jobs requeridos: `fixture-build` y `fixture-tests` (`.github/workflows/fixture.yml`). El job de pruebas
designado es `fixture-tests`: una corrida RED es la que lo tiene en `failure`. `Ci` pass exige los dos en `success` en la corrida `push` del SHA exacto.

## Identidades y secretos

Autor y committer sintéticos (`fixture <fixture@example.invalid>`). Ningún secreto real. Los `Claim-Id` del fixture empiezan por `fc62f1c7-`.
