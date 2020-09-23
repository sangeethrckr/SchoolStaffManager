import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ABC School Staff Management';

  ChangeNavActiveColor(staffType : number){
    
    switch(staffType){
      case 1:
        document.getElementById("TnavButton").className = "navButton   active";
        document.getElementById("AnavButton").className = "navButton";
        document.getElementById("SnavButton").className = "navButton";
        break;
      case 2:
        document.getElementById("TnavButton").className = "navButton";
        document.getElementById("AnavButton").className = "navButton   active";
        document.getElementById("SnavButton").className = "navButton";
        break;
        
      case 3:
        document.getElementById("TnavButton").className = "navButton";
        document.getElementById("AnavButton").className = "navButton";
        document.getElementById("SnavButton").className = "navButton   active";
        break;
        
    }

  }

}

