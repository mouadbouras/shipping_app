import { Component, AfterViewChecked  } from '@angular/core';
import { UserService } from './services/user.service';
import { User } from './model/user.model';

declare let paypal: any;


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent{// implements AfterViewChecked {
  title = 'shipping-app';

  addScript: boolean = false;
  paypalLoad: boolean = false;
  
  finalAmount: number = 1;

  public user : User;

  constructor(private userServcie: UserService) { }

  ngOnInit() {
    this.userServcie.getUser().subscribe(u => this.user = u);
    console.log();
  }

  // paypalConfig = {
  //   env: 'sandbox',

  //   style: {
  //     layout: 'vertical',  // horizontal | vertical
  //     size:   'medium',    // medium | large | responsive
  //     shape:  'rect',      // pill | rect
  //     color:  'gold'       // gold | blue | silver | black
  //   },

  //   client: {
  //     sandbox: 'AWRVQkrwfja1nTxBmCmf5-NZSpqEN54cDWqCjopM7k5e-rrootzxQePt_gdo4rp4ZdX6gCijXREphUTZ',
  //     production: 'AWRVQkrwfja1nTxBmCmf5-NZSpqEN54cDWqCjopM7k5e-rrootzxQePt_gdo4rp4ZdX6gCijXREphUTZ'
  //   },
  //   commit: true,
  //   payment: (data, actions) => {
  //     return actions.payment.create({
  //       payment: {
  //         transactions: [
  //           { amount: { total: this.finalAmount, currency: 'USD' } }
  //         ]
  //       }
  //     });
  //   },
  //   onAuthorize: (data, actions) => {
  //     return actions.payment.execute().then((payment) => {
  //       //Do something when payment is successful.
  //     })
  //   }
  // };

  // ngAfterViewChecked(): void {
  //   if (!this.addScript) {
  //     this.addPaypalScript().then(() => {
  //       paypal.Button.render(this.paypalConfig, '#paypal-checkout-btn');
  //       this.paypalLoad = false;
  //     })
  //   }
  // }
  
  // addPaypalScript() {
  //   this.addScript = true;
  //   return new Promise((resolve, reject) => {
  //     let scripttagElement = document.createElement('script');    
  //     scripttagElement.src = 'https://www.paypalobjects.com/api/checkout.js';
  //     scripttagElement.onload = resolve;
  //     document.body.appendChild(scripttagElement);
  //   })
  // }

}
