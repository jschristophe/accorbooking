pipeline {
  agent any
  stages {
    stage('Stage 1') {
      parallel {
        stage('Stage 1') {
          steps {
            echo 'test build'
          }
        }
        stage('Build 2A') {
          steps {
            echo 'build parralle 2'
          }
        }
      }
    }
    stage('Stage 2') {
      steps {
        echo 'test Release'
      }
    }
  }
}