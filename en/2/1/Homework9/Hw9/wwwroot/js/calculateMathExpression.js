const expressionInput = $("#mathExpression");
const requestUrl = "/Calculator/CalculateMathExpression";
const resultOutput = $("#response");

function calculateMathExpression(){
    let requestBody = {
        expression: expressionInput.val()
    };
    
    $.post({
        url: requestUrl,
        data: requestBody,
        success: function (request){
            let message = request.isSuccess 
                ? `Result: ${request.result}`
                : `Error: ${request.errorMessage}`;
            
            resultOutput.text(message);
        },
        error: function(XMLHttpRequest) {
            resultOutput.text(`Ошибка на сервере: ${XMLHttpRequest.responseText}`);
        }
    });
    
    return false;
}

$("#calculateBtn").on("click", calculateMathExpression);