import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Chatting App';

  users: any;

  constructor(private http: HttpClient) { }
  
  ngOnInit(): void {
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
}
