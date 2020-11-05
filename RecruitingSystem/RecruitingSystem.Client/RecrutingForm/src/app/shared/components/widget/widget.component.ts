import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-widget',
  templateUrl: './widget.component.html',
  styleUrls: ['./widget.component.css']
})
export class WidgetComponent implements OnInit {

  @Input() widgetContent: string;
  @Input() redirectLink: string;

  constructor() { }

  ngOnInit() {
  }

}
