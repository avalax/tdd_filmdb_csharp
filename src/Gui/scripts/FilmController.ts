declare var $: any;

/// <reference path="FilmService.ts" />
/// <reference path="FilmRenderer.ts" />
/// <reference path="NotificationRenderer.ts" />

namespace filmdb_app {

    export class FilmController {
        constructor(
            private readonly filmService: FilmService,
            private readonly filmRenderer: FilmRenderer,
            private readonly notificationRenderer: NotificationRenderer
        ) {
        }

        async loadFilms(): Promise<void> {
            const button = $('#load-films-btn');
            const originalText = button.text();

            try {
                button.text('Loading...').prop('disabled', true).addClass('loading');

                const films = await this.filmService.getAllFilms();
                this.filmRenderer.renderFilmsContainer(films);
            } catch (error) {
                console.error('Error loading films:', error);
                this.notificationRenderer.showNotification('Failed to load films. Please try again.', 'error');
            } finally {
                button.text(originalText).prop('disabled', false).removeClass('loading');
            }
        }

        async viewFilmDetails(filmId: number): Promise<void> {
            try {
                const film = await this.filmService.getFilmById(filmId);
                this.notificationRenderer.showNotification(`Film Details: ${film.title} (${film.year}) by ${film.director}`, 'info');
            } catch (error) {
                console.error('Error loading film details:', error);
                this.notificationRenderer.showNotification(`Failed to load details for film ID: ${filmId}`, 'error');
            }
        }
    }
}