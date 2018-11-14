import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  startDate: string;
  location: string;
  name :string;

  constructor(private http: HttpClient) { }
  tournaments: any;
  SaveTournament() {
      this.http.post("http://localhost:5000/api/tournament",{name:this.name,location:this.location, startDate: this.startDate})
      .subscribe(a=> this.tournaments.push({name:this.name,location:this.location, startDate: this.startDate}));
  }
  


  ngOnInit(): void {
    this.http.get("http://localhost:5000/api/tournament").subscribe(resp => {
      this.tournaments = resp;
    });
  }
}


export class Tournament { }
