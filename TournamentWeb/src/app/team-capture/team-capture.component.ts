import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-team-capture',
  templateUrl: './team-capture.component.html',
  styleUrls: ['./team-capture.component.css']
})
export class TeamCaptureComponent implements OnInit {
  name: string;
  coach: string;
  captain: string;
  teams: any[];
  constructor(private http: HttpClient) {}

  ngOnInit() {}

  SaveTeam() {
    this.http
      .post('http://localhost:5000/api/team', {
        name: this.name,
        coach: this.coach,
        captain: this.captain
      })
      .subscribe(a =>
        this.teams.push({
          name: this.name,
          coach: this.coach,
          captain: this.captain
        })
      );
  }
}
