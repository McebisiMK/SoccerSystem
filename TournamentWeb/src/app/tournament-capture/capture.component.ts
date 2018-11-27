import { Router } from "@angular/router";
import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-capture",
  templateUrl: "./capture.component.html",
  styleUrls: ["./capture.component.css"]
})
export class CaptureComponent implements OnInit {
  name: string;
  location: string;
  startDate: string;
  tournaments: any;
  constructor(private http: HttpClient, private router: Router) {}

  ngOnInit(): void {
    this.http.get("http://localhost:5000/api/tournament").subscribe(
      resp => {
        this.tournaments = resp;
      },
      e => {}
    );
  }

  loadDetails(id) {
    this.router.navigate(["/tournament/details/", id]);
  }

  SaveTournament() {
    this.http
      .post("http://localhost:5000/api/tournament", {
        name: this.name,
        location: this.location,
        startDate: this.startDate
      })
      .subscribe(a =>
        this.tournaments.push({
          name: this.name,
          location: this.location,
          startDate: this.startDate
        })
      );
  }
}
