document.addEventListener('DOMContentLoaded', () => {

    // 1) Mostrar solo los campos propios del tipo seleccionado
    const tipo = document.getElementById('Tipo');
    const grupos = document.querySelectorAll('[data-grupo-tipo]');

    function mostrarGrupo() {
        grupos.forEach(grupo => {
            const activo = grupo.dataset.grupoTipo === tipo.value;
            grupo.hidden = !activo;
            // Los campos ocultos se deshabilitan: no se validan ni se envían
            grupo.querySelectorAll('input, select').forEach(campo => { campo.disabled = !activo; });
        });
    }

    if (tipo && grupos.length) {
        tipo.addEventListener('change', mostrarGrupo);
        mostrarGrupo();
    }

    // 2) Dosis instantánea: consulta al servidor cada vez que cambia el valor
    const entrada = document.getElementById('dosisPorKg');
    const salida = document.getElementById('dosisResultado');

    if (entrada && salida) {
        let consulta = null;

        entrada.addEventListener('input', async () => {
            const valor = entrada.value.trim();
            if (valor === '') { salida.textContent = '—'; return; }

            if (consulta) consulta.abort();
            consulta = new AbortController();

            try {
                const url = `${entrada.dataset.url}?dosisPorKg=${encodeURIComponent(valor)}`;
                const respuesta = await fetch(url, { signal: consulta.signal });
                if (!respuesta.ok) { salida.textContent = 'Valor no válido'; return; }
                const datos = await respuesta.json();
                salida.textContent = `${datos.dosis.toFixed(2)} mg`;
            } catch (e) {
                if (e.name !== 'AbortError') salida.textContent = 'No se pudo calcular';
            }
        });
    }

    // 3) Confirmación antes de eliminar
    document.querySelectorAll('form[data-confirmar]').forEach(formulario => {
        formulario.addEventListener('submit', evento => {
            if (!confirm(formulario.dataset.confirmar)) evento.preventDefault();
        });
    });
});