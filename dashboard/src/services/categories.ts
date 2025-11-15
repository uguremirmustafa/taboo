import { client } from '../utils/client';

export async function getCategories() {
  const response = await client.GET('/api/Categories');
  return response;
}
