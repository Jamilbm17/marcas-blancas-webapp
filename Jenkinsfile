pipeline {
    agent any

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = '1'
        DOTNET_NOLOGO = '1'
        DOTNET_SKIP_FIRST_TIME_EXPERIENCE = '1'
        SOLUCION = 'MarcasBlancas.slnx'
        PROYECTO_WEB = 'src/MarcasBlancas.Web/MarcasBlancas.Web.csproj'
    }

    stages {

        stage('Clonar repositorio') {
            steps {
                checkout scm
                bat 'dotnet --info'
            }
        }

        stage('Restaurar dependencias') {
            steps {
                bat "dotnet restore \"%SOLUCION%\""
            }
        }

        stage('Compilar') {
            steps {
                bat "dotnet build \"%SOLUCION%\" --configuration Release --no-restore"
            }
        }

        stage('Ejecutar pruebas') {
            steps {
                bat "dotnet test \"%SOLUCION%\" --configuration Release --no-build"
            }
        }

        stage('Publicar aplicacion') {
            steps {
                bat "dotnet publish \"%PROYECTO_WEB%\" --configuration Release --no-build --output publish"
                archiveArtifacts artifacts: 'publish/**', fingerprint: true
            }
        }
    }

    post {
        success { echo 'Pipeline completado correctamente.' }
        failure { echo 'El pipeline fallo. Revisa el log de la etapa.' }
    }
}
