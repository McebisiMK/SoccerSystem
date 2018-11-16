import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-tournaments',
  templateUrl: './tournaments.component.html',
  styleUrls: ['./tournaments.component.css']
})
export class TournamentsComponent implements OnInit {
tournaments: any;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get("http://localhost:5000/api/tournament").subscribe(resp => {
      this.tournaments = resp;
    },e=>{});
  }

}
