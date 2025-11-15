import createClient from 'openapi-fetch';
import type { paths } from '../types/schema';

export const client = createClient<paths>({ baseUrl: 'http://localhost:5047' });
