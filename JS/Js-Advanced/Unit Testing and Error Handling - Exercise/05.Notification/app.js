function notify(message) {
  const container = document.getElementById('notification');
  container.textContent = message;

  container.style.display = 'block';

  container.addEventListener('click', () => {
    container.style.display = 'none';
  });
}