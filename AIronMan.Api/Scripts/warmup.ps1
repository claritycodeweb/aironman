$apiKey = "SomeKey"
$resource = "http://localhost/AIronMan.Api/api/account/Authenticate"
$body = @{
       UserName = "admin"
       Password = "svc123"
}

$listCounters = 
@{Alias = "auth"; 
                    CounterGroupName= "RESPONSE_TIME";      
                    Url="http://localhost/AIronMan.Api/api/account/Authenticate";  
                    Token = "OXR4eXnM8LHSgBW9tEijCW5Sm"; 
                    CounterUnitOfMeasure = "ms";
                    Method = "POST";
                    Body = @{
                            UserName = "admin"
                            Password = "svc123"
                    }
                 },
@{Alias = "warmup"; 
                    CounterGroupName= "RESPONSE_TIME";      
                    Url="http://localhost/AIronMan.Api/Api/account/WarmUp";  
                    Token = "OXR4eXnM8LHSgBW9tEijCW5Sm"; 
                    CounterUnitOfMeasure = "ms";
                    Method = "GET";
                 }


foreach ($counter in $listCounters) {
    write-host $counter.Url
    if ($counter.Method -eq "POST") {       
        Invoke-RestMethod -Method Post -Uri $counter.Url -Body (ConvertTo-Json $counter.Body) -Header @{"Authentication"=$apiKey} -ContentType application/json
    }else{
        Invoke-RestMethod -Method Get -Uri $counter.Url -Header @{ "X-ApiKey" = $apiKey }
    }
}


