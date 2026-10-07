# FX-U1 — decisiones y órdenes del Coordinator del fixture (SISTEMA BAJO PRUEBA)

Plano (c). Nada de este archivo acredita un gate, un READY, una aprobación del Owner ni una integración fuera de este repositorio.

## Orden FX-U1-O1 — apertura de la unidad por su Principal

```text
FIXTURE-ORDER: FX-U1-O1
Unit: FX-U1
Plane: c (TEST-ACTIVATION)
```

1. **Autoverificación (16.15-16.16).** Dentro de tu sesión, tres preflights `rackcad-preflight/v1` para la acción CUSTODY, cada uno con la observación
   del runtime ligada a su instante (`get_session`). Guárdalos en `docs/automation/evidence/FX-U1-agent/autoverificacion/preflight-<n>.json`. Entre uno y
   otro, el Owner cambia el effort de la sesión. Con CUSTODY en BELOW_REQUIRED o UNKNOWN: STOP P-09 de CUSTODY, sin tomar la custodia, y espera el
   cambio siguiente.
2. **Arranque (§8.6, AUTOMATION_PLAN 16.28).** Con CUSTODY en MATCH o ABOVE_REQUIRED: publica el BOOTSTRAP de FX-U1 (`docs/automation/state/FX-U1.yml`,
   `rackcad-automation-state/v2`) con tu binding propuesto en PENDING y tu preflight CUSTODY custodiados, en `fx/u1` (push a `origin` y a `github`).
   Después espera en este archivo la decisión G0 de este Coordinator, con los marcadores de 16.28.
3. **Aceptaciones.** Con G0 ACCEPTED: el QU con las aceptaciones. Después espera aquí el contrato de la tarea T1.
4. **Transportes.** No invoques `codex-cli` hasta que este Coordinator lo autorice aquí: hoy su transporte está detenido por un cambio de huella
   (P-01), pendiente de una decisión del Owner.
5. **Plano (c).** No nombres, no configures y no uses ningún repositorio real (P-16).

## Decisión G0 de FX-U1 (Coordinator del fixture)

Sobre el BOOTSTRAP `1746b404e57d69170ecfc084fd24fa3e699916d7` (`record_version` 1): estado `rackcad-automation-state/v2`, binding del Principal
`B20261006T220601Z-cfe1` (`rackcad-binding/v1`) y preflight CUSTODY `P20261006T220134Z-20ab` (ELIGIBLE), validados contra los esquemas del fixture.
G0 GATE PASS con adopción I62 y aceptación del binding propuesto:

```text
I62-DELEGATED-EXECUTION: I62_DELEGATED
I62-CLASSIFICATION: I62
I62-PRINCIPAL-BINDING: B20261006T220601Z-cfe1 ACCEPTED
Claim-Id: fc62f1c7-0000-4000-8000-000000000001
BootstrapRecordVersion: 1
```

Siguiente paso de la orden FX-U1-O1: el QU con las aceptaciones; después, espera aquí el contrato de la tarea T1.

## Orden FX-U1-O2 — contrato de T1 y punto quiescente de relevo (QH)

```text
FIXTURE-ORDER: FX-U1-O2
Unit: FX-U1
Plane: c (TEST-ACTIVATION)
Contract: docs/automation/decisions/FX-U1-T1.gate-contract.json (rackcad-gate-contract/v2, blob 628d89af5f21e4e14cbe7c3c14f0dd8fb5a490e0)
```

1. **Contrato.** Este Coordinator emite el contrato de la tarea T1 en la ruta de arriba (en este mismo commit; `AuthorityRevision` y
   `MaterializationCloseSha` = el BOOTSTRAP `1746b404`; `MainSha` = F_eff). Custódialo según 16.20-16.22.
2. **Relevo.** No abras ventana ni planifiques T1. Publica el punto **QH** de FX-U1 por CAS (`rackcad-automation-state/v2`): `task_intent` = T1 (`Attempt`
   vigente, FIRST, contrato custodiado, Controller de planificación con binding pendiente), `principal.state` = RELEASED y `window` CLOSED. Push a `origin`
   y a `github`.
3. **Terminación.** Tras el push del QH, termina tu sesión: no hagas nada más en este repositorio.
4. **Transportes.** No invoques `codex-cli` ni lances subagentes en esta orden.
5. **Plano (c).** No nombres, no configures y no uses ningún repositorio real (P-16).

## Orden FX-U1-O3 — reparación del QH r3 por un titular temporal R (T16 → QR ORDINARY → QH)

```text
FIXTURE-ORDER: FX-U1-O3
Unit: FX-U1
Plane: c (TEST-ACTIVATION)
Repairs: QH ae25b596a11fe3508ac60a3ef7de5dc23df971ce (record_version 3)
```

**Hecho.** El QH r3 viola I-S13 e I-S16: `protocol.g0_acceptance.decision` y `custody.principal.acceptance.decision` citan
`docs/automation/decisions/FX-U1.md` con el blob `bdc8e4ddc0d939bf4a0622b26487dca1b58c304f`, que ya no es el del archivo en el árbol del punto (el archivo de
decisiones solo crece por añadido). Ninguna otra invariante de archivo, de par ni de historia falla. El QH r3 se conserva como evidencia histórica: no se
reescribe, no se enmienda y su titular liberado no vuelve a operar.

**Lectura de este Coordinator.** «`protocol.g0_acceptance` cambia una sola vez» se refiere a la transición semántica de la aceptación (PENDING → ACCEPTED o
REJECTED), no a la identidad física del blob de un `StateRef` cuyo destino es un archivo de decisiones que solo crece por añadido. Con G0 aceptado: el estado
sigue ACCEPTED, la decisión y su marcador siguen siendo los mismos, la ruta no cambia y el blob del `StateRef` debe resolver en el árbol del punto durable
vigente; cuando el archivo crece, el blob se refresca al del archivo en ese árbol. La respuesta dada dentro de la sesión del titular anterior no es autoridad
normativa y queda sustituida por esta lectura.

**Titular de reparación R** (designación acotada; no es el titular anterior ni la sesión que medirá la reanudación):
1. **Observación.** Tu preflight `rackcad-preflight/v1` para CUSTODY con la observación del runtime ligada a su instante (`get_session`). Con BELOW_REQUIRED o
   UNKNOWN: STOP P-09 y espera.
2. **Propuesta.** Con CUSTODY en MATCH o ABOVE_REQUIRED, tu binding `rackcad-binding/v1` (rol PRINCIPAL_COORDINATOR, `Scope` UNIT, aceptación PENDING).
   Publica la observación y la propuesta en `docs/automation/evidence/FX-U1-agent/repair/` de `fx/u1` (push a `origin` y a `github`), **sin** escribir el
   estado. Después espera aquí la designación de este Coordinator con `I62-PRINCIPAL-BINDING: <tu BindingId> ACCEPTED`.
3. **QR ORDINARY** (T16), tras la designación: `record_version` siguiente; titular HELD con tu binding aceptado y tu preflight custodiados; la designación
   por `StateRef`; **todo** `StateRef` a `docs/automation/decisions/FX-U1.md` refrescado al blob del archivo en el árbol del QR; `g0_acceptance.state`
   ACCEPTED y la decisión G0 original sin cambio semántico; contadores, `task_intent` y contrato de T1 sin cambios. Ni decisión G0 nueva, ni cambio de T1,
   ni Q0, ni planificación, ni delegaciones, ni invocaciones.
4. **QH** (T17), inmediatamente después: titular RELEASED, ventana CLOSED, sin cambios semánticos nuevos y con todos los `StateRef` resolviendo en su propio
   árbol. Push a `origin` y a `github`.
5. **Terminación.** Tras el push del QH, termina tu sesión: no hagas nada más en este repositorio.
6. **Validación.** Antes de cada push, valida el punto (esquema, `StateRef` en el árbol del propio commit, par con el punto anterior). Una violación no se
   publica: STOP y espera aquí.
7. **Transportes y plano (c).** No invoques `codex-cli` ni lances subagentes. No nombres, no configures y no uses ningún repositorio real (P-16).

## Designación acotada del titular de reparación R (Coordinator del fixture; orden FX-U1-O3)

Terminación del titular anterior acreditada por la sesión de supervisión (metadatos `isRunning` = false desde 2026-10-06T23:17:18Z, sin actividad tras el
QH r3 `ae25b596`). Observación de R `P20261007T023103Z-01b1` (CUSTODY: MATCH, ELIGIBLE; commit `badbf930`) y propuesta `B20261007T023706Z-5fdd`
(`rackcad-binding/v1`, PRINCIPAL_COORDINATOR, `Scope` UNIT; commit `9ce50a52`) validadas contra los esquemas del fixture. Designación acotada a la
reparación de la orden FX-U1-O3: el QR ORDINARY (T16) con los `StateRef` al archivo de decisiones refrescados y el QH inmediato; nada más.

```text
I62-PRINCIPAL-BINDING: B20261007T023706Z-5fdd ACCEPTED
Claim-Id: fc62f1c7-0000-4000-8000-000000000001
```

**Fe de erratas de la designación anterior:** el commit de la propuesta `B20261007T023706Z-5fdd` es `9ce50a5ec3dad421c277424c3df861b3591ac224` (no `9ce50a52`); el marcador y el `BindingId` no cambian.
