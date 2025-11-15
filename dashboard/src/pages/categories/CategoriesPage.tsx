import { useLoaderData } from 'react-router';

function CategoriesPage() {
  const { categories } = useLoaderData();
  return (
    <div>
      <div>CategoriesPage</div>
      <pre>{JSON.stringify(categories, null, 2)}</pre>
    </div>
  );
}

export default CategoriesPage;
