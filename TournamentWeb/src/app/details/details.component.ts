import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  tournament: Object;

  constructor(private http: HttpClient, private activeRoute: ActivatedRoute, private router: Router) { }

  ngOnInit() {

    this.activeRoute.params.subscribe(params => {
      if (params['name']) {
        let detailName = params['name'];
        this.http.get("http://localhost:5000/api/tournament/find/by/name/"+detailName).subscribe(resp => {
          this.tournament = resp;
        }, e => { });
      }
    })
  }
}