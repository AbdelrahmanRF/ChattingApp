import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  registerMode = false;
  users : any 
  constructor(private http: HttpClient) { }
  
  registerToggle() {
    this.registerMode = !this.registerMode
  }

    getUsers() {
      this.http.get('https://localhost:5001/users')
      .subscribe({
        next: r => this.users = r,
        error: this.handelError,
        complete: () => console.log('request is completed')
    })
    }
  
    private handelError(err: any) {
    console.log("Response Error, Status:", err.status);
    console.log("Response Error, Status Text:", err.statusText);
    console.log(err);
    }
  
  cancelregisterMode(event: boolean) {
    this.registerMode = event;
  }
  
}
