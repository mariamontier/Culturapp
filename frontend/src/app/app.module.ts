import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { FaqComponent } from './pages/faq/faq.component';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [AppComponent, FaqComponent],
  imports: [BrowserModule, CommonModule],
  bootstrap: [AppComponent],
})
export class AppModule {}
