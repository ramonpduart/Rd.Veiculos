workspace {

    model {
    
        user = person "User" "Gerente de uma concession�ria de ve�culos"
        
         veiculoSystem = softwareSystem "Rd Veiculos" "Software para gest�o de ve�culos" {
         
            veiculoBd = container "Base de dados" "Base de Dados" {
                
                properties {
					technology "SQL Server"
                }
            }
            
            rdVeiculosApi = container "Veiculo - API" {
                user -> this "Utiliza"
                
                properties {
					technology ".net core 6"
                }
                
                veiculoController = component "VeiculoController" "Controller para recebimento das requisi��es http"
                adicionarVeiculoCommandHandler = component "AdicionarVeiculoCommandHandler" "Handler para adi��o de um novo Veiculo"
                alterarVeiculoCommandHandler = component "AlterarVeiculoCommandHandler" "Handler para altera��o de um Veiculo"
                excluirVeiculoCommandHandler = component "excluirVeiculoCommandHandler" "Handler para exclus�o de um Veiculo"
                veiculoRepository = component "VeiculoRepository" "Repositorio para leitura/escrita das informa��es do veiculo"
                
                veiculoController -> adicionarVeiculoCommandHandler "Invoka o handler"
                adicionarVeiculoCommandHandler -> veiculoRepository "Adiciona um novo veiculo a base"
                
                veiculoController -> alterarVeiculoCommandHandler "Invoka o handler"
                alterarVeiculoCommandHandler -> veiculoRepository "Altera um veiculo a base"
                
                veiculoController -> excluirVeiculoCommandHandler "Invoka o handler"
                excluirVeiculoCommandHandler -> veiculoRepository "Exclui um veiculo a base"
                
                veiculoRepository -> veiculoBd "Leitura/Escrita na base"
            }
            
       }
    }

    views {
        systemContext veiculoSystem "ContextVeiculo" {
            include *
            autolayout lr
            description "[Nivel 4] Diagrama de contexto da solu��o de gerenciamento de veiculos"
        }

        container veiculoSystem "ContainerVeiculo" {
            include *
            autolayout lr
            description "[Nivel 3] Diagrama de container da solu��o de gerenciamento de veiculos"
        }
        
        component rdVeiculosApi "ComponentVeiculo" {
			include *            
			autoLayout lr
			description "[Nivel 2] Diagrama de componente da solu��o de NPS do RAC"
        }

        theme default
    }
 
}