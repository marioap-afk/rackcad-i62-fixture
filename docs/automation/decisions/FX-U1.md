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
