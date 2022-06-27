pipeline{
    agent any

    parameters{
        choice(
            name:   "ENVIRONMENT",
            choices: ["localhost","dev","pre","prod"]
        )
        choice(
            name:   "REQUESTED_ACTION"
            choices:["DEFAULT","DEPLOY_STACK","UPDATE_SERVICE",]
            description:"Tarea a realizar"
        )
    }

    stages{
        stage("Test"){
            script{
                echo "> HAGO TEST"
                // fnSteps.test(config)
            }
        }
        stage("Build"){
            script{
                echo "> Build"
                // fnSteps.test(config)
            }
        }

        stage("Deploy stack"){
            script{
                echo "> Deploy stack"
                // fnSteps.test(config)
            }
        }

        stage("Update service"){
            script{
                echo "> Update service"
                // fnSteps.test(config)
            }
        }
    }


}