workspace {
    model {
        inf = softwareSystem "Задание инфа (Витрина)" "То что делают на информатике" "ASP.NET MVC" {
            db = container DB
            mvc = container MVC
            mvc -> db
        }
        
        dotnet2 = softwareSystem "Задание .NET (Админка)" "То что делают на дотнете" "ASP.NET WebAPI + React" {
            chatDb = container ChatDB "" "Mongo?"
            newDb = container NewDB
            
            api = container "REST API"
            gql = container "GQL API"
            chat = container "CHAT"
            
            broker = container "Brocker"
            
            newDb -> broker
            db -> broker
            
            gql -> newDb
            chat -> chatDb
            api -> db
        }
        
        mobile = softwareSystem Mobile
        mobile -> gql
        
    }   
    
    views {
        theme default
        
        container dotnet2 {
            include api ->db db-> chat-> ->gql gql->
            autoLayout
        }
    }
}