import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-alert-danger',
  templateUrl: './alert-danger.component.html'
})
export class AlertDangerComponent implements OnInit {
  
  @Input() errors: any[] = [];
  constructor() { }

  ngOnInit() {
  }

}
