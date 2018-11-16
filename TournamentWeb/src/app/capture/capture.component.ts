import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-capture',
  templateUrl: './capture.component.html',
  styleUrls: ['./capture.component.css']
})
export class CaptureComponent implements OnInit {
name: string;
location: string;
startDate: string;
tournaments: any[];
  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  SaveTournament() {
    this.http.post("http://localhost:5000/api/tournament",{name:this.name,location:this.location, startDate: this.startDate})
    .subscribe(a=> this.tournaments.push({name:this.name,location:this.location, startDate: this.startDate}));
}

}
