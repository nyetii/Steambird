<script setup lang="ts">
import PostsVue from './components/Posts.vue';
import HelloWorld from './components/HelloWorld.vue'
import TheWelcome from './components/TheWelcome.vue'
</script>

<template>
  <header>
    <div>
      <nav class="navbar">
        <a href="/" class="logo"><img alt="Logo" class="logo" src="./assets/logo.svg" width="125" height="125" /></a>

        <ul class="nav-list">
          <li><a href="/">Home</a></li>
          <li><a href="/milkshake">Milkshake.NET</a></li>
        </ul>

        <a href="https://github.com/nyetii/" class="icon-anchor"><img class="icon" alt="GitHub" src="./assets/github.svg" width="32" height="31"/></a>
      </nav>
    </div>
  </header>

  <main>
    <RouterView></RouterView>
  </main>
</template>

<style scoped>
  template {
    display: flex;
    flex-direction: column;
  }

  main {
    margin-top: 4em;
  }

  header {
    margin: 1em 0 2em 0;
    line-height: 1.5;
    position: absolute;
    top: 0;
  }

  .logo {
    display: block;
    width: 5em;
    height: auto;
    margin: 0 auto 2rem;
    cursor: pointer;
  }

  .icon-anchor,
  .icon-anchor:hover {
    border-radius: 50%;
    width: 35px;
    height: 34px;
  }

  @media (min-width: 1024px) {
    header {
      display: flex;
      place-items: center;
      padding-right: calc(var(--section-gap) / 2);
    }
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  .logo:hover{
    background-color:transparent;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }

  .navbar{
    display: flex;
    justify-items: center;
    align-items: center;
    flex-direction: row;
  }

  .nav-list {
    list-style-type: none;
    margin: 0;
    padding: 0;
    display: flex;
    justify-items: center;
  }

  .nav-list li {
    margin-right: 15px;
  }

  .nav-list a {
    text-decoration: none;
    color: #fff;
    font-weight: bold;
    transition: color 0.3s ease;
  }

  /* Add some styles to highlight the current page or active link */
  .nav-list a:hover,
  .nav-list a:focus {
    color: #ffcc00;
  }
  
</style>
