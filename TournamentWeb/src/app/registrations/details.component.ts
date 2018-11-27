import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-details",
  templateUrl: "./details.component.html",
  styleUrls: ["./details.component.css"]
})
export class DetailsComponent implements OnInit {
  defaultTeamSelection: { label: string; value: string };
  resetRegistrationForm(): any {
    this.amount = undefined;
    this.defaultTeamSelection = { label: "Select Team", value: "" };
  }
  tournament: any;
  teams: any;
  activeTournamentId: number;
  selectedTeamId: number;
  registeredTeams: any;
  amount: number;

  constructor(
    private http: HttpClient,
    private activeRoute: ActivatedRoute,
    private router: Router
  ) {}

  register() {
    const registration = {
      teamId: this.selectedTeamId,
      tournamentId: this.activeTournamentId,
      amount: this.amount
    };
    this.http
      .post(`http://localhost:5000/api/registration`, registration)
      .subscribe(a => {
        this.loadRegisteredTeams(this.activeTournamentId);
        this.resetRegistrationForm();
      });
  }

  ngOnInit() {
    this.activeRoute.params.subscribe(params => {
      if (params["id"]) {
        this.activeTournamentId = params["id"];
        this.loadRegisteredTeams(this.activeTournamentId);

        this.http
          .get(
            `http://localhost:5000/api/tournament/find/by/id/${
              this.activeTournamentId
            }`
          )
          .subscribe(
            resp => {
              this.tournament = resp;
            },
            e => {}
          );
      }
    });
    this.http.get("http://localhost:5000/api/team").subscribe(
      resp => {
        this.teams = resp;
      },
      e => {}
    );
  }

  private loadRegisteredTeams(id) {
    this.http
      .get(`http://localhost:5000/api/registration/${id}`)
      .subscribe(response => (this.registeredTeams = response));
  }
}
