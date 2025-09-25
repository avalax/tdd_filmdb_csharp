declare var $: any;

namespace filmdb_app {
    
    export class NotificationRenderer {
        private escapeHtml(text: string): string {
            const div = document.createElement('div');
            div.textContent = text;
            return div.innerHTML;
        }

        showNotification(message: string, type: 'success' | 'error' | 'warning' | 'info'): void {
            const alertClass = `alert-${type === 'error' ? 'danger' : type}`;
            const notification = $(`
            <div class="alert ${alertClass} alert-dismissible fade show position-fixed"
                 style="top: 20px; right: 20px; z-index: 9999; min-width: 300px;">
                ${this.escapeHtml(message)}
                <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
            </div>
        `);

            $('body').append(notification);

            setTimeout(() => {
                notification.alert('close');
            }, 5000);
        }
    }
}