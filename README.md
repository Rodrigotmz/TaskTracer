# Task Tracker - Aplicación de Línea de Comandos para Gestión de Tareas

## Descripción del Proyecto

Task Tracker es una sencilla aplicación de línea de comandos (CLI) desarrollada en .NET Framework diseñada para ayudarte a organizar y gestionar tus tareas de manera eficiente. Con esta herramienta, podrás realizar un seguimiento de tus pendientes, registrar las tareas completadas y mantener un control de lo que estás trabajando actualmente.

Este proyecto es una excelente oportunidad para practicar tus habilidades de programación en .NET Framework, incluyendo la interacción con el sistema de archivos, el manejo de la entrada del usuario y la construcción de una aplicación CLI funcional.

## Funcionalidades Principales

La aplicación Task Tracker permite realizar las siguientes acciones:

* **Añadir una nueva tarea:** Permite ingresar una nueva tarea a la lista de pendientes.
* **Actualizar una tarea:** Permite modificar la descripción de una tarea existente.
* **Eliminar una tarea:** Permite remover una tarea de la lista.
* **Marcar una tarea como en progreso:** Permite señalar que estás trabajando en una tarea específica.
* **Marcar una tarea como completada:** Permite indicar que una tarea ha sido finalizada.
* **Listar las tareas:** Muestra todas las tareas registradas, o filtradas por su estado.

## Cómo Utilizar

Para ejecutar la aplicación Task Tracker, sigue estos pasos:

1.  **Clonar el repositorio (si aplica):** Si este proyecto está en un repositorio (por ejemplo, en GitHub), clónalo a tu máquina local utilizando Git.
    ```bash
    git clone [https://github.com/sindresorhus/del](https://github.com/sindresorhus/del)
    ```
2.  **Navegar al directorio del proyecto:** Abre la terminal o símbolo del sistema y dirígete a la carpeta donde se encuentra el archivo ejecutable de la aplicación.
    ```bash
    cd TaskTracker
    ```
3.  **Ejecutar la aplicación:** Ejecuta el archivo ejecutable. Dependiendo de cómo se haya construido el proyecto, esto podría ser un archivo `.exe`.
    ```bash
    task-cli [comando] [argumentos]
    ```

### Ejemplos de Uso

Aquí tienes algunos ejemplos de cómo interactuar con la aplicación Task Tracker:

* **Añadir una nueva tarea:** Utiliza el comando `add` seguido de la descripción de la tarea entre comillas.
    ```bash
    task-cli add "Comprar comestibles"
    ```
    **Salida esperada:**
    ```
    Tarea añadida exitosamente (ID: 1)
    ```

* **Actualizar una tarea:** Utiliza el comando `update` seguido del ID de la tarea y la nueva descripción entre comillas.
    ```bash
    task-cli update 1 "Comprar comestibles y preparar la cena"
    ```

* **Eliminar una tarea:** Utiliza el comando `delete` seguido del ID de la tarea que deseas eliminar.
    ```bash
    task-cli delete 1
    ```

* **Marcar una tarea como en progreso:** Utiliza el comando `mark-in-progress` seguido del ID de la tarea.
    ```bash
    task-cli mark-in-progress 1
    ```

* **Marcar una tarea como completada:** Utiliza el comando `mark-done` seguido del ID de la tarea.
    ```bash
    task-cli mark-done 1
    ```

* **Listar todas las tareas:** Utiliza el comando `list`.
    ```bash
    task-cli list
    ```
    **Salida esperada (ejemplo):**
    ```
    ID: 1 - Estado: Completada - Descripción: Comprar comestibles y preparar la cena
    ID: 2 - Estado: Pendiente - Descripción: Llamar al técnico
    ID: 3 - Estado: En progreso - Descripción: Escribir informe
    ```

* **Listar tareas por estado:** Utiliza el comando `list` seguido del estado deseado (`done`, `todo`, `in-progress`).
    ```bash
    task-cli list --done
    ```
    **Salida esperada (ejemplo):**
    ```
    ID: 1 - Estado: Completada - Descripción: Comprar comestibles y preparar la cena
    ```
    ```bash
    task-cli list --todo
    ```
    **Salida esperada (ejemplo):**
    ```
    ID: 2 - Estado: Pendiente - Descripción: Llamar al técnico
    ```
    ```bash
    task-cli list --in-progress
    ```
    **Salida esperada (ejemplo):**
    ```
    ID: 3 - Estado: En progreso - Descripción: Escribir informe
    ```

## Requisitos del Sistema

* Sistema operativo Windows 10 (de preferencia instalado la version 10).
* .NET 8 instalado.


https://roadmap.sh/projects/task-tracker