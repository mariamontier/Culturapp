import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-perfil-usuario',
  templateUrl: './perfil-usuario.component.html',
  styleUrls: ['./perfil-usuario.component.css'],
  imports: [CommonModule, ReactiveFormsModule, FormsModule, RouterModule],
})
export class PerfilUsuarioComponent implements OnInit {
  formulario: FormGroup;
  abaDadosAtiva: string = 'perfil';

  usuario = {
    nome: 'Paula Fernandes Jacobina',
    userName: 'paulafernandes',
    email: 'paulafernandes@gmail.com',
    emailTruncado: 'paulafernandes@gm....',
    telefone: '17 9999-9999',
    documento: '0000',
    nascimento: '28-01-1988',
    foto: 'assets/img/usuario.png',
    endereco: 'Rua das Flores, 123, São Paulo, SP',
  };

  constructor(private fb: FormBuilder, private router: Router) {
    this.formulario = this.fb.group({
      nome: [this.usuario.nome],
      userName: [this.usuario.userName],
      email: [this.usuario.email],
      telefone: [this.usuario.telefone],
      documento: [this.usuario.documento],
      nascimento: [this.usuario.nascimento],
      endereco: [this.usuario.endereco],
    });
  }

  ngOnInit(): void {}

  mudarAbaDados(aba: string): void {
    this.abaDadosAtiva = aba;
  }

  salvarDados(): void {
    if (this.formulario.valid) {
      console.log('Dados salvos:', this.formulario.value);
      this.usuario = { ...this.usuario, ...this.formulario.value };
    }
  }

  sair(): void {
    console.log('Usuário saiu do sistema');
    // Aqui você pode adicionar a lógica de logout
  }

  eventos = [
    {
      nome: 'Angular Conf 2024',
      descricao: 'Evento sobre Angular e boas práticas',
      status: 'Concluído',
    },
    {
      nome: 'Semana Dev Frontend',
      descricao: 'Palestras sobre UI/UX e tendências',
      status: 'Em andamento',
    },
    {
      nome: 'Hackathon SP',
      descricao: 'Maratona de programação de 48h',
      status: 'Inscrito',
    },
  ];
}
