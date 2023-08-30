import { Injectable, Renderer2, RendererFactory2 } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {
  private renderer: Renderer2;
  private currentTheme = 'light'; // Default to light theme

  constructor(private rendererFactory: RendererFactory2) {
    this.renderer = rendererFactory.createRenderer(null, null);
  }

  toggleTheme() {
    this.currentTheme = this.currentTheme === 'dark' ? 'light' : 'dark';
    const body = document.querySelector('body');
    this.renderer.removeClass(body, this.currentTheme === 'dark' ? 'light-theme' : 'dark-theme');
    this.renderer.addClass(body, this.currentTheme === 'dark' ? 'dark-theme' : 'light-theme');
  }
}