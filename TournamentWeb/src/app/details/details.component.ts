import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  tournament: any = [];
  teams: any = [];
  activeTournamentId: number;
  selectedTeamId: number;
  registeredTeams = [{ name: "Mcera" }, { name: "Mqanduli" }];
  amount: number;

  constructor(private http: HttpClient, private activeRoute: ActivatedRoute, private router: Router) { }

  register() {
    const registration = { teamId: this.selectedTeamId, tournamentId: this.activeTournamentId, amount: this.amount };
    this.http.post(`http://localhost:5000/api/registration`, registration).subscribe(a => { });
  }

  ngOnInit() {
    this.activeRoute.params.subscribe(params => {
      if (params['id']) {
        this.activeTournamentId = params['id'];
        this.http.get(`http://localhost:5000/api/tournament/find/by/id/${this.activeTournamentId}`).subscribe(resp => {
          this.tournament = resp;
        }, e => { });
      }
    });
    this.http.get('http://localhost:5000/api/team').subscribe(resp => {
      this.teams = resp;
    }, e => { });
  }
}
