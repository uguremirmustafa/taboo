import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import './index.css';
import { createBrowserRouter } from 'react-router';
import { RouterProvider } from 'react-router/dom';
import HomePage from './pages/home/Home.tsx';
import CategoriesPage from './pages/categories/CategoriesPage.tsx';
import { getCategories } from './services/categories.ts';

const router = createBrowserRouter([
  {
    path: '/',
    children: [
      { index: true, Component: HomePage },
      {
        path: 'categories',
        Component: CategoriesPage,
        loader: async () => {
          return { categories: await getCategories() };
        },
      },
    ],
  },
]);

const root = document.getElementById('root')!;

createRoot(root).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>
);
