declare var $: any;

/// <reference path="api-client.ts" />
/// <reference path="FilmService.ts" />
/// <reference path="FilmRenderer.ts" />
/// <reference path="NotificationRenderer.ts" />
/// <reference path="FilmController.ts" />

namespace filmdb_app {
    
    export class FilmDbApp {
        private readonly controller: FilmController;
        private readonly filmService: FilmService;
        private readonly filmRenderer: FilmRenderer;
        private readonly notificationRenderer: NotificationRenderer;

        constructor() {
            this.filmService = new FilmService(window.location.origin);
            this.filmRenderer = new FilmRenderer();
            this.notificationRenderer = new NotificationRenderer();
            this.controller = new FilmController(this.filmService, this.filmRenderer, this.notificationRenderer);

            this.initializeEventHandlers();
        }
        
        private initializeEventHandlers(): void {
            $('#load-films-btn').on('click', () => this.controller.loadFilms());
            $('#filmsLink').on('click', (e: any) => {
                e.preventDefault();
                this.controller.loadFilms();
            });
        }
    }
    
    $(() => {
        (window as any).app = new FilmDbApp();
        console.log('FilmDb SPA initialized successfully!');
    });
}