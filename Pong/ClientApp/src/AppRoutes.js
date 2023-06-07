import { GameHistory } from "./components/GameHistory";
import { GameCreation } from "./components/GameCreation";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/game-creation',
    element: <GameCreation />
  },
  {
    path: '/game-history',
    element: <GameHistory />
  }
];

export default AppRoutes;
