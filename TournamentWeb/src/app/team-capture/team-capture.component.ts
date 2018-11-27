import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";

@Component({
  selector: "app-team-capture",
  templateUrl: "./team-capture.component.html",
  styleUrls: ["./team-capture.component.css"]
})
export class TeamCaptureComponent implements OnInit {
  name: string;
  coach: string;
  captain: string;
  teams: any;
  constructor(private http: HttpClient, private router: Router) {}

  ngOnInit(): void {
    this.http.get("http://localhost:5000/api/team").subscribe(
      resp => {
        this.teams = resp;
      },
      e => {}
    );
  }

  SaveTeam() {
    this.http
      .post("http://localhost:5000/api/team", {
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
