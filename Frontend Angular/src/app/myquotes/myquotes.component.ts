import { Component, OnInit } from '@angular/core';
import { QuoteService } from '../Services/quote.service';
import { Quote } from '../Model/quote.model';



@Component({
  selector: 'app-myquotes',
  templateUrl: './myquotes.component.html',
  styleUrls: ['./myquotes.component.css']
})
export class MyquotesComponent implements OnInit {

  private quotes = new Array<Quote>();


  constructor(private quoteServcie: QuoteService) { }

  ngOnInit() {
    this.quoteServcie.quoteOB.subscribe(res => this.quotes = res);
  }

}
