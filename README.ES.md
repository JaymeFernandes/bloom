# 🌸 Repositorio del Lenguaje de Programación BLOOM 🌸

¡Bienvenido al repositorio oficial del lenguaje de programación Bloom! Este es un proyecto personal en el que estoy trabajando con mucha pasión. Siéntete libre de explorar, probar y compartir tus comentarios. ¡Tu opinión es muy valiosa!

## Selector de Idioma 🌐
- [Read-me en English](./README.md)
- [Read-me en Português](./README.PT-BR.md)
- [Read-me en Español](README.ES.md)

## **Cómo Configurar:**

### 📥 Clonar el Repositorio

Primero, clona el repositorio usando git:

```bash
git clone https://github.com/Nauzoo/bloom
```

### 🖥️ Instrucciones para Windows:

1. **Crear un Archivo Ejecutable**

   Ejecuta el siguiente comando para crear un archivo ejecutable:

   ```bash
   pyinstaller --noconfirm --onedir --console --icon "./assets/bloom_ico.ico" --name "BLOOM" --log-level "DEBUG"  "./source/interpreter.py"
   ```

   > Nota: Necesitas [PyInstaller](https://pyinstaller.org/en/stable/) para ejecutar este comando.

2. **Agregar a las Variables de Entorno**

   Agrega la carpeta que contiene `florish.ps1` a tus variables de entorno:

   ![Variables de Entorno](/assets/enviroment.png)

3. **Modificar la Ruta en `florish.ps1`**

   Asegúrate de que la ruta a tu ejecutable del intérprete esté correctamente configurada en `florish.ps1`:

   ![Ruta al Ejecutable](/assets/exe_path.png)

4. **Ejecutar el Intérprete**

   Ahora puedes ejecutar el intérprete con:

   ```bash
   florish ruta_al_archivo.bloom
   ```

   ![Ejecutando Código](/assets/run_code.png)

   ¡Este repositorio incluye algunos códigos de ejemplo para que puedas probar!

---

¡Disfruta programando con Bloom! Si encuentras algún problema o tienes sugerencias, no dudes en abrir un issue o pull request. ¡Feliz programación! 🌼