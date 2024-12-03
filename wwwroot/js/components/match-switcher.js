class MatchSwitcher extends HTMLElement {
    constructor() {
        super();
        const shadowRoot = this.attachShadow({ mode: 'open' });

        const container = document.createElement('div');
        container.classList.add('switcher-container');

        const matchType = this.getAttribute('match-type') || '';

        container.innerHTML = `
            <button class="switch-button ${matchType === 'SCHEDULED' ? 'active' : ''}" data-type="SCHEDULED">Upcoming Matches</button>
            <button class="switch-button ${matchType === 'FINISHED' ? 'active' : ''}" data-type="FINISHED">Recent Matches</button>
        `;

        container.querySelectorAll('.switch-button').forEach(button => {
            button.addEventListener('click', () => {
                const type = button.getAttribute('data-type');
                showSpinnerAndRedirect(`/Matches/GetMatches?type=${type}`);
            });
        });

        const styleLink = document.createElement('link');
        styleLink.rel = 'stylesheet';
        styleLink.href = '/css/components/match-switcher.css';

        shadowRoot.appendChild(styleLink);
        shadowRoot.appendChild(container);
    }
}

customElements.define('match-switcher', MatchSwitcher);