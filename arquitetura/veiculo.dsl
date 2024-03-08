workspace {

    model {
    
        user = person "User" "Gerente de uma concessionária de veículos"
        
         veiculoSystem = softwareSystem "Rd Veiculos" "Software para gestão de veículos" {
         
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
                
                veiculoController = component "VeiculoController" "Controller para recebimento das requisições http"
                adicionarVeiculoCommandHandler = component "AdicionarVeiculoCommandHandler" "Handler para adição de um novo Veiculo"
                alterarVeiculoCommandHandler = component "AlterarVeiculoCommandHandler" "Handler para alteração de um Veiculo"
                excluirVeiculoCommandHandler = component "excluirVeiculoCommandHandler" "Handler para exclusão de um Veiculo"
                veiculoRepository = component "VeiculoRepository" "Repositorio para leitura/escrita das informações do veiculo"
                
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
            description "[Nivel 4] Diagrama de contexto da solução de gerenciamento de veiculos"
        }

        container veiculoSystem "ContainerVeiculo" {
            include *
            autolayout lr
            description "[Nivel 3] Diagrama de container da solução de gerenciamento de veiculos"
        }
        
        component rdVeiculosApi "ComponentVeiculo" {
			include *            
			autoLayout lr
			description "[Nivel 2] Diagrama de componente da solução de NPS do RAC"
        }

        theme default
    }
 
}