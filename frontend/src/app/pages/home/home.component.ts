import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})


export class HomeComponent {
  eventos = [
    {
      titulo: 'Linkin Park: FROM ZERO WORLD TOUR',
      local: 'Allianz Parque, São Paulo',
      data: 'novembro de 2023',
      preco: 'R$ 350,00',
      imagem: 'https://images.unsplash.com/photo-1468234847176-28606331216a?q=80&w=1000',
    },
    {
      titulo: 'Coldplay: MUSIC OF THE SPHERES',
      local: 'Estádio Nilton Santos, Rio de Janeiro',
      data: 'dezembro de 2023',
      preco: 'R$ 450,00',
      imagem: 'https://images.unsplash.com/photo-1470229722913-7c0e2dbbafd3?q=80&w=1000',
    },
    {
      titulo: 'Hamlet - Teatro Nacional',
      local: 'Teatro Nacional, Brasília',
      data: 'outubro de 2023',
      preco: 'R$ 180,00',
      imagem: 'https://images.unsplash.com/photo-1503095396549-807759245b35?q=80&w=1000',
    },
    {
      titulo: 'Festival de Jazz',
      local: 'Parque Barigui, Curitiba',
      data: 'setembro de 2023',
      preco: 'R$ 220,00',
      imagem: 'https://images.unsplash.com/photo-1514320291840-2e0a9bf2a9ae?q=80&w=1000',
    },
  ];

  constructor(private router: Router) {}

  verDetalhes(evento: any) {
    // Redirecionar para detalhes do evento (a definir rota)
    alert(`Ver detalhes de: ${evento.titulo}`);
  }

  verTodosEventos() {
    this.router.navigate(['/eventos']);
  }

  buscar() {
    alert('Função de busca em desenvolvimento');
  }

}
