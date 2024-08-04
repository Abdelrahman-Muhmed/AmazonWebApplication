import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-cards',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './cards.component.html',
  styleUrl: './cards.component.css'
})
export class CardsComponent {
  name:string = "Headsets"
  // src:string = "../../../assets/image/h1.jpeg"
gName:string = "Gaming accessories"

headerCards:any[] = [
  {headerName: "Gaming accessories"},
  {headerName: "Shop deals in Fashion"},
  {headerName: "Deals in PCs"},
  {headerName: "Refresh your space"}
]
cards: any[] = [
  {
    headerName: "Gaming accessories",
    items: [
      { name: "Headsets", src: "./assets/image/h1.jpeg" },
      { name: "Keyboards", src: "./assets/image/h3.jpeg" },
      { name: "Computer Mouse", src: "./assets/image/h2.jpeg" },
      { name: "Chairs", src: "./assets/image/h4.jpeg" }
    ]
  },
  {
    headerName: "Fashion trends you like",
    items: [
      {name: "Dresses" , src: "../../../assets/image/h5.jpeg"},
      {name: "Knits" , src: "../../../assets/image/h6.jpeg"},
      {name: "jackets" , src: "../../../assets/image/h7.jpeg"},
      {name: "jewelry" , src: "../../../assets/image/h8.jpeg"}

    ]
  }

]

  event():void {
  alert("Hello");
}
onSale:boolean = true; //==> When i start use *ngFor Try Do That Styling and Class Binding
}

