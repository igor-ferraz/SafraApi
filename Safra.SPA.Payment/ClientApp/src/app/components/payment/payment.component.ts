import { Component, OnInit } from '@angular/core';
import { PaymentService } from 'src/app/services/payment-service'

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  constructor(private paymentService: PaymentService) { }

  ngOnInit() {
    this.GetSales();
  }

  GetSales() {
    this.paymentService.GetSales("4B359A02-E53A-4DCC-88A3-1279F2C118EF").subscribe(
      (response) => {
        console.log(response);
      });
  }
}
