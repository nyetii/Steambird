<script setup lang="ts">
import PostsVue from './components/Posts.vue';
import HelloWorld from './components/HelloWorld.vue'
import TheWelcome from './components/TheWelcome.vue'
</script>

<template>
  <header>
    <nav class="navbar">
      <img alt="Logo" class="logo" src="./assets/logo.svg" width="125" height="125" />

      <ul class="nav-list">
        <li><a href="#">Home</a></li>
        <li><a href="/memes">Gerar Memes</a></li>
      </ul>
    </nav>
  </header>

  <main>
    <RouterView></RouterView>
    <p>Posts</p>
    <PostsVue></PostsVue>
  </main>
</template>

<style scoped>
  header {
    line-height: 1.5;
    position: fixed;
    top: 0;
  }

  .logo {
    display: block;
    width: 5em;
    margin: 0 auto 2rem;
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
