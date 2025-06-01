import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-eventpage',
  templateUrl: './eventpage.component.html',
  styleUrls: ['./eventpage.component.css']
})
export class EventpageComponent {

  constructor(private router: Router) {}

  buyTicket(): void {
    // Lógica para comprar ingresso
    this.router.navigate(['/checkout']);
  }

   verCadastro() {
    this.router.navigate(['/cadastro']);
  }
    verLogin() {
    this.router.navigate(['/login']);
  }
}
