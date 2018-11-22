import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {


  teams: any;
  tournaments: any;
  constructor(private http: HttpClient, private router: Router) { }
  ngOnInit() {
    this.http.get('http://localhost:5000/api/team').subscribe(resp => {
      this.teams = resp;
    }, e => {});

    this.http.get('http://localhost:5000/api/tournament').subscribe(resp => {
      this.tournaments = resp;
    }, e => {});
  }

}
