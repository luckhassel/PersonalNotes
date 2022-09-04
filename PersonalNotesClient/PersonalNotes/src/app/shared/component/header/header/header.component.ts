import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private readonly routerService: Router) { }
  @Input() displayExit = false;

  ngOnInit(): void {
  }

  exit(){
    localStorage.removeItem('token');
    this.routerService.navigateByUrl('');
  }
}
