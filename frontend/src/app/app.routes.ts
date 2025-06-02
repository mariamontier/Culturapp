import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { CadastroComponent } from './pages/cadastro/cadastro.component';
import { EventpageComponent } from './pages/eventpage/eventpage.component';
import { CriarEventoComponent } from './pages/criar-evento/criar-evento.component';
import { EditarEventoComponent } from './pages/editar-evento/editar-evento.component';
import { FaqComponent } from './pages/faq/faq.component';
import { SobreComponent } from './pages/sobre/sobre.component';
import { PerfilUsuarioComponent } from './pages/perfil-usuario/perfil-usuario.component';
import { PerfilEmpresaComponent } from './pages/perfil-empresa/perfil-empresa.component';

export const routes: Routes = [

  { path: '', redirectTo: 'home', pathMatch: 'full' },

  { path: 'login', component: LoginComponent },
  { path: 'cadastro', component: CadastroComponent },
  { path: 'eventpage', component: EventpageComponent },
  { path: 'criar-evento', component: CriarEventoComponent },
  { path: 'editar-evento', component: EditarEventoComponent },
  { path: 'faq', component: FaqComponent },
  { path: 'sobre', component: SobreComponent },
  {
    path: 'home',
    loadComponent: () =>
      import('./pages/home/home.component').then((m) => m.HomeComponent),
  },
  { path: 'perfil-usuario', component: PerfilUsuarioComponent },
  { path: 'perfil-empresa', component: PerfilEmpresaComponent },

  { path: '**', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})

export class AppRoutingModule { }
