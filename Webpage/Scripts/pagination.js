
var perPage = 3;
var currPage = 1;

function pagination(data){

    var divContainer = document.getElementById("showData");
    var entryCount = data.length;
    var pageCount = Math.floor( (entryCount-1) / perPage );
    

    var firstPage = document.createElement("input");
    firstPage.type = "button";
    firstPage.value = "First";
    firstPage.className = "pagination-button";
    firstPage.id = "first-page";
    firstPage.onclick = ()=>{FirstPage();}
    divContainer.appendChild(firstPage);

    var previousPage = document.createElement("input");
    previousPage.type = "button";
    previousPage.value = "Previous";
    previousPage.className = "pagination-button";
    previousPage.id = "previous-page";
    previousPage.onclick = ()=>{PreviousPage();}
    divContainer.appendChild(previousPage);

    for(var i = 0;i <=  pageCount;i++){
        var pageButton = document.createElement("input");
        pageButton.type = "button";
        pageButton.value = i + 1;
        pageButton.className = "pagination-button";
        pageButton.id = i;
        divContainer.appendChild(pageButton);

        pageButton.onclick = function(){
            currPage = parseInt(this.id);
            NextPage();
            this.style.backgroundColor = "#333";
            
        }
    }

    var nextPage = document.createElement("input");
    nextPage.type = "button";
    nextPage.value = "Next";
    nextPage.className = "pagination-button";
    nextPage.id = "next-page";
    nextPage.onclick = ()=>{NextPage();}
    divContainer.appendChild(nextPage);

    var lastPage = document.createElement("input");
    lastPage.type = "button";
    lastPage.value = "Last";
    lastPage.className = "pagination-button";
    lastPage.id = "last-page";
    lastPage.onclick = ()=>{
        currPage = pageCount;
        NextPage();
    }
    divContainer.appendChild(lastPage);

  

    

    function FirstPage(){
        var tableExists = document.getElementById('staffTable');
        if(tableExists != null){
            tableExists.remove();
        }
        var end;
        if(perPage > entryCount){
            end = entryCount;
        }
        else{
            end = perPage;
        }
        table = CreateTableFromJSON(data,0,end);
        table.setAttribute('id','staffTable');
        divContainer.appendChild(table);
        currPage = 1;
        focusPage();
    }

    
    function NextPage(){
        var start = currPage * perPage;
        var end = start + perPage;
        if(start >= entryCount){
            return;
        }
        else if(end > entryCount){
            end = entryCount;
        }
        document.getElementById('staffTable').remove();
        table = CreateTableFromJSON(data,start,end);
        table.setAttribute('id','staffTable');
        divContainer.appendChild(table);
        currPage = currPage +1;
        focusPage(entryCount);
            
    
    }

    function PreviousPage(){

        var start = ((currPage -1) * perPage) - perPage;
        var end = start + perPage;
        if(start < 0){
            return;
        }
        document.getElementById('staffTable').remove();
        table = CreateTableFromJSON(data,start,end);
        table.setAttribute('id','staffTable');
        divContainer.appendChild(table);
        currPage = currPage - 1;
        focusPage();
    }
    
    function focusPage(){
        for(var i = 0;i <=  pageCount;i++){
            if(i==(currPage -1)){
                document.getElementById(i).style.backgroundColor = "#333";
            }
            else{
                document.getElementById(i).style.backgroundColor = "#254e58c4";
            }
        }
    }

    FirstPage();
}




